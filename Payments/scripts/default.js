/// <reference path="webConfiguration.js" />
/// <reference path="angular.min.js" />

var residence = (function () {
    var i;
    var thisObject = {
        buildOutput: function (div, data) {
            var result = $("<p>");
            for (i = 0; i < data.length; i++) {
                var p = $("<p>").html(data[i].id);
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
            $http.get(webConfiguration.apiBaseAddress + 'api/Residence')
                .success(function (data /*, status, headers, config*/) {
                    callback(data);
                });
        }
    };
}]);

app.service('testApiService', function () {
    var houses = [
        {
            id: 2732,
            homeowner: {
                name: "Mike and Leann Cordenoy",
                address: "2732 North Test",
                city: "Maxville",
                state: "CA",
                zip: "91256"
            }
        },
        {
            id: 2740,
            homeowner: {
                name: "Cheryl and Lance Armstrong",
                address: "2740 North Test",
                city: "Maxville",
                state: "CA",
                zip: "91256"
            }
        }];

    return {
        callWebApi: function (callback) {
            callback(houses);
        }
    };
});


$(function () {
    $.get(webConfiguration.apiBaseAddress + "api/Residence")
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

