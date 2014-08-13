var demoApp = angular.module('demoApp', []);
demoApp.controller("EmpController", ['$scope', '$http', function ($scope, $http) {

    $http.get('/Employees/GetEmployees').success(function (data) {

        $scope.Employees = data;

    }).error(function (message) {

        var msg = message; debugger;
    });
}]);