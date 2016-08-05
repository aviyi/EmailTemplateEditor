$(function () {

    var $createTemplatePage;
    var $createTemplatePage;
    var $subject;
    if ($('#editor-text-area').length > 0)
        CKEDITOR.replace('editor-text-area', {
            filebrowserImageUploadUrl: '/EmailTemplate/UploadImage'
        })

    CKEDITOR.on('instanceReady', init);


    function init() {


        $createTemplatePage = $('#create-tempalte-page');
        $dropDown = $createTemplatePage.find('#listItemsDD');
        $subject = $createTemplatePage.find('#Subject');
        $ckeEditorTextArea = $createTemplatePage.find("#cke_editor-text-area");

        $('#create-tempalte-page').submit(function () {
            ckText = $("#cke_editor-text-area iframe").contents().find("body").text();


            removeWorng();
            var isValid = false;
            if (!$dropDown.val() && $createTemplatePage.data('is-edit-mode') == "False") {
                $dropDown.addClass('input-no-valid');
                return isValid;
            }
            if (!$subject.val()) {
                $subject.addClass('input-no-valid');
                return isValid;
            }

            if (ckText === "") {
                $ckeEditorTextArea.addClass('input-no-valid');
                return isValid;

            }
            isValid = true;
            return isValid;
        })

    }
    function removeWorng() {
        $dropDown.removeClass('input-no-valid');
        $subject.removeClass('input-no-valid');
        $createTemplatePage.removeClass('input-no-valid');

    }


})