/// <reference path="angular.min.js" />

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

var app = angular.module('accountBook', []);

app.controller('AccountBookController', ['restApiService', function (dataService) {
    var self = this;

    dataService.callWebApi(function (data) {
        self.houses = data;
    });
}]);

app.service('restApiService', ['$http', function ($http) {
    return {
        callWebApi: function (callback) {
            $http.get('api/Residence')
                .success(function (data, status, headers, config) {
                    callback(data);
                });
        }
    }
}]);

app.service('testApiService', function () {
    var houses = [
        {
            Id: 2732,
            Homeowner: {
                Name: "Mike and Leann Cordenoy",
                Address: "2732 North Test",
                City: "Maxville",
                State: "CA",
                Zip: "91256"
            }
        },
        {
            Id: 2740,
            Homeowner: {
                Name: "Cheryl and Lance Armstrong",
                Address: "2740 North Test",
                City: "Maxville",
                State: "CA",
                Zip: "91256"
            }
        }];

    return {
        callWebApi: function (callback) {
            callback(houses);
        }
    }
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

