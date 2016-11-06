$(function () {
    $('#StartingDate')
        .datetimepicker({
            format: 'MM.DD.YYYY HH:mm',
            locale: "ru",
            minDate: new Date()
        });

    var bestPictures = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,

        remote: {
            url: '../api/films/%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#remote .form-control').typeahead(null, {
        name: 'best-pictures',
        display: 'Name',
        source: bestPictures
    });

    var numSelectedHandler = function (eventObject, suggestionObject, suggestionDataset) {
        $("#FilmID").val(suggestionObject.ID);
    };
    $('#remote').on('typeahead:selected', numSelectedHandler);
});
