angular.module('Payments', [])
    .directive('paymentsResident', function(){
    return {
        restrict: E,
        templateUrl: 'payments-resident.html'
    };
});