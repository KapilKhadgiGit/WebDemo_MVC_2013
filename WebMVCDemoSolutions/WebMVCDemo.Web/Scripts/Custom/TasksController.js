var demoApp = angular.module('demoApp', []);

// If the module is already defined somewhere else then use below line.
var demoApp = angular.module('demoApp');

// deptApp.controller('DeptController', function ($scope, $http) {
demoApp.controller('TaskController', ['$scope', '$http', function ($scope, $http) {


    $http.get('/TaskManager/GetAllTasks').success(function (data) {
        $scope.tasks = data;

        $scope.overDueItems = 0;

        // Ideally Angular should be able to parse date directly to date object, but its not. So removing 'Date' string appended to the date format. 
        // Exact formatting of the date can be be set at view.
        angular.forEach($scope.tasks, function (item) {
            item.DueDate = item.DueDate.replace('/Date(', '').replace(')/', '');

            // Get the number of over due items from the task list.
            $scope.currentDate = Date.now();

            if (item.DueDate != null) {
                if ($scope.currentDate > item.DueDate) {
                    $scope.overDueItems++;
                }
            }
        });

    }).error(function (msg) {
        var message = msg;
        debugger;
    });

    $scope.createTask = function () {

        if (this.newTask.Title.trim() == '') {
            // alert('Title can not be blank!');
            debugger;
        }
        else {
            $http.post('/TaskManager/Create', this.newTask).success(function (data) {
                alert("Added Successfully!!");
                $scope.tasks.push(data);

            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Friend! " + data;
            });
        }
    };

}]);

//jQuery(function () {
//    jQuery('#datetimepicker1').datepicker();
//});