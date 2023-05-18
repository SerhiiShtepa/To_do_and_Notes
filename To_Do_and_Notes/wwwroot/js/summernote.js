window.initializeSummernote = function (dotNetReference) {
    $('#summernoteNew').summernote({
        placeholder: 'Hello stand alone ui',
        tabsize: 2,
        height: 120,
        toolbar: [
            ['font', ['bold', 'underline']],
            ['insert', ['picture']],
        ],
        callbacks: {
            onChange: function (content) {
                dotNetReference.invokeMethodAsync('SummerNoteChange', content);
            }
        }
    });
    $('#summernoteEdit').summernote({
        placeholder: 'Hello stand alone ui',
        tabsize: 2,
        height: 120,
        toolbar: [
            ['font', ['bold', 'underline']],
            ['insert', ['picture']],
        ]
    });
};
