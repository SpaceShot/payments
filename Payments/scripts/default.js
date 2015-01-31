var residence = (function () {
    var i;
    var thisObject = {
        buildOutput: function (div, data) {
            var result = $("<p>");
            for (i = 0; i < data.length; i++) {
                var p = $("<p>").html(data[i].Id);
                result.append(p);
            }
            $(div).html(result);
        }
    };

    return thisObject;
}());
var houses = [{
    Id: 2732, Homeowner: {
        Name: "Mike and Leann Cordenoy",
        Address: "2732 N Barley Sheaf Road",
        City: "Coatesville",
        State: "PA",
        Zip: "19320"
    }
},
{
    Id: 2740, Homeowner: {
        Name: "Cheryl and Lance Armstrong",
        Address: "2740 N Barley Sheaf Road",
        City: "Coatesville",
        State: "PA",
        Zip: "19320"
    }
}];
var app = angular.module('accountBook', []);
app.controller('AccountBookController', function () {
    this.houses = houses;
});
$(function () {
    $('#jqueryCanary').html('Yep, we&#39re good');

    $.get("api/Residence")
        .done(function (data) {
            console.log(data);
            residence.buildOutput($("#residences"), data);
        });

    // click functions for each action
    $('.tools').on('click', function () {
        $(this).toggleClass('expand').toggleClass('hidden');
        $('.tools').toggleClass('hidden');
        //$('.assess').toggleClass('hidden');
        //$('.ledger').toggleClass('hidden');
    });
});

