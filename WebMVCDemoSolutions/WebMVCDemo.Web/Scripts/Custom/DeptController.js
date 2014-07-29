var deptApp = angular.module('deptApp', []);

// deptApp.controller('DeptController', function ($scope, $http) {
deptApp.controller('DeptController', ['$scope', '$http', function ($scope, $http) {

    //$scope.departments = [{ 'DeptName': 'Software', 'Location': 'GA' }, { 'DeptName': 'Sitecore', 'Location': 'FB' }];

    $http.get('/Departments/GetDepartments').success(function (data) {
        $scope.departments = data;

    }).error(function (msg) {
        var message = msg;
        debugger;
    });

}]);