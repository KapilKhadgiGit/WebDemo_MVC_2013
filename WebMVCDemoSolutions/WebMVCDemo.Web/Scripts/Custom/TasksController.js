var demoApp = angular.module('demoApp', []);

// deptApp.controller('DeptController', function ($scope, $http) {
demoApp.controller('TaskController', ['$scope', '$http', function ($scope, $http) {

    $http.get('/TaskManager/GetAllTasks').success(function (data) {
        $scope.tasks = data;

    }).error(function (msg) {
        var message = msg;
        debugger;
    });

}]);