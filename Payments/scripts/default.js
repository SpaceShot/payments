var residence = (function () {
    var i;
    var thisObject = {
        buildOutput: function (div, data) {
            var result = $("<p>");
            for (i=0; i<data.length; i++) {
                var p = $("<p>").html(data[i].Id);
                result.append(p);
            }
            $(div).html(result);
        }
    };

    return thisObject;
}());


$(function () {
    $('#jqueryCanary').html('Yep, we&#39re good');

    $.get("api/Residence")
        .done(function (data) {
            console.log(data);
            residence.buildOutput($("#residences"), data);
        });
});