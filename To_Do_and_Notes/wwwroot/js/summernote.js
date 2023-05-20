window.initializeSummernote = function (dotNetReference) {
    $('#summernoteNew').summernote({
        disableDragAndDrop: true,
        disableResizeImage: true,
        placeholder: 'Hello stand alone ui',
        tabsize: 2,
        height: 120,
        toolbar: [
            ['font', ['bold', 'italic', 'underline']],
            ['insert'],
        ],
        callbacks: {
            onChange: function (content) {
                dotNetReference.invokeMethodAsync('NewSummerNote', content);
            }
        }
    });
    $('#summernoteEdit').summernote({
        disableDragAndDrop: true,
        disableResizeImage: true,
        placeholder: 'Hello stand alone ui',
        tabsize: 2,
        height: 120,
        toolbar: [
            ['font', ['bold', 'italic', 'underline']],
            ['insert'],
        ],
        callbacks: {
            onChange: function (content) {
                dotNetReference.invokeMethodAsync('EditSummerNote', content);
            }
        }
    });
    
};

function setSummernoteEditContent(content) {
    $('#summernoteEdit').summernote('code', content);
}