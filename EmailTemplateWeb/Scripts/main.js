$(function () {
     
    if ($('#editor-text-area').length>0)
     CKEDITOR.replace('editor-text-area')

    $('#home-btn').click(function () {
         window.location.href = '/home/index';
    })
});