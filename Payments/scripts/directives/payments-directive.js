angular.module('Payments', [])
    .directive('paymentsResident', function(){
    return {
        restrict: "E",
        templateUrl: 'payments-resident.html',
        controller: function($scope){
            $scope.id = "1001";
            $scope.owner = "Sally Mae";
            $scope.balance = "0";
        }
    };
});