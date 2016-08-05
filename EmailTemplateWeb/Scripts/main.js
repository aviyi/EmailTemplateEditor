$(function () {

    var ddBranches = $('#home-page-container').find('#branchesDD');
    //in order to dipalt ck edit
    
    $('#home-btn').click(function () {
        window.location.href = '/home/index';
    })

    $('#events-btn').click(function (e) {

        e.preventDefault();

        $('#btns-container').fadeOut(function () {
            $('#dd-branches-container').fadeIn();

        });

    })

    $('#create-template').click(function () {

        if (!ddBranches.val()) {
            ddBranches.addClass('no-valid');
            return;
        }
        else {
            window.location.href = "/EmailTemplate?type=Event&sug_lid=" + 1 + "&branchId=" + ddBranches.val();
        }

    })



});