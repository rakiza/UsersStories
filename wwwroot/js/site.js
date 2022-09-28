function RemoveValidationUnobtrusive(id) {
    var $form = $(id);
    if ($form.length) {
        $form.removeData("validator")
            .removeData("unobtrusiveValidation");
    }
}

function InitValidationUnobtrusive(id) {
    var $form = $(id);
    if ($form.length) {
        console.log("InitValidationUnobtrusive");
        $form.removeData("validator") /* added by the raw jquery.validate plugin */
            .removeData("unobtrusiveValidation");
        /* added by the jquery unobtrusive plugin */
        $.validator.unobtrusive.parse($form);
        // $.validator.unobtrusive.
    }
}

function addStory() {
    var actorId = $("#Filter_ActorId").val();
    $.ajax({
        type: "GET",
        data: {"actorId":actorId},
        url: "/Stories/Create?handler=AddStory",       
        success: function (response) {
            $("#list-stories").append(`${response}`);           
            InitValidationUnobtrusive(`#story-form`);            
            InitStoryUI();
            console.log("adding new story");
            console.log($("#new-story-ui").offset().top);
            $('html, body').animate({
                scrollTop: $("#new-story-ui").offset().top
            }, 2000);
        },
        failure: function (response) {
            //alert(response);
        }
    });
}

function InitStoryUI() {
    $(".cancel-add-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        $($(this).data("target")).remove();
    });

    $(".cancel-edit-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var target = $($(this).data("target"));
        var id = $(this).data("id");
        
        $.ajax({
            type: "GET",
            url: "/Stories/Create?handler=CancelEditStory",
            data: {"id":id},            
            success: function (result) {
                target.html(result);
                InitStoryUI();
            },
            failure: function (response) {
                //alert(response);
            }
        }
        );
    });

    $(".clone-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var id = $(this).data("id");

        $.ajax({
            type: "GET",
            url: "/Stories/Create?handler=CloneStory",
            data: { "id": id },
            success: function (result) {
                $("#list-stories").append(result);
                InitStoryUI();
            },
            failure: function (response) {
                //alert(response);
            }
        }
        );
    });


    $(".delete-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var target = $($(this).data("target"));
        var storyId = $(this).data("id");
        $.ajax({
            type: "GET",
            data: { "id": storyId },
            url: "/Stories/Create?handler=DeleteStory",
            success: function (response) {
                if (response.hasError === false) {
                    target.remove();
                } else {

                }
            },
            failure: function (response) {
                //alert(response);
            }
        });
    });

    $(".edit-mode-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var target = $($(this).data("target"));
        var storyId = $(this).data("id");
        $.ajax({
            type: "GET",
            data: { "id": storyId },
            url: "/Stories/Create?handler=EditStory",
            success: function (response) {
                console.log(response);
                target.html(response);
                InitStoryUI();
            },
            failure: function (response) {
                //alert(response);
            }
        });
    });

    $(".edit-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var target = $($(this).data("target"));
        
        var id = $(this).data("id");
        var $form = $(`#story-form-${id}`);

        $.ajax({
            type: "POST",
            url: "/Stories/Create?handler=EditStory",
            data: $form.serialize(),
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            success: function (result) {                
                target.html(result);                
                InitStoryUI();
            },
            failure: function (response) {
                //alert(response);
            }
        }
        );

    });

    $(".actor-change").off("change").on("change", function () {
        var css = $("#Color").val();
        var targetId = $(this).data("id");        
        var actorId = $(this).val();        
        $.ajax({
            type: "GET",
            data: {"id":actorId},
            url: "/Stories/Create?handler=ActorColor",
            success: function (response) {                
                $(`#story-content-${targetId}`).removeClass(`alert-${css}`).addClass(`alert-${response.color}`);
            },
            failure: function (response) {
                //alert(response);
            }
        });
    });

    $(".add-story").off("click").on("click", function (e) {
        e.preventDefault();
        e.stopPropagation();

        var target = $($(this).data("target"));
        
        var id = $(this).data("id");
        var $form = $(`#story-form-${id}`);
        
        $.ajax({
            type: "POST",
            url: "/Stories/Create?handler=CreateStory",
            data: $form.serialize(),
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            success: function (result) {                
                target.remove();
                $("#list-stories").append(result);
                InitStoryUI();
            },
            failure: function (response) {
                //alert(response);
            }
        }
        );    
                
    });
}

$(".add-new-story").on("click", function (e) {
    e.preventDefault();
    addStory();
});

InitStoryUI();














