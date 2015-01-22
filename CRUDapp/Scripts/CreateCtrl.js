angular.module('TodoApp').controller('CreateCtrl', ['$scope', 'TodoFactory', function ($scope, TodoFactory) {
    $scope.save = function () {
        TodoFactory.save($scope.item, function () {
            $location.path('/');
        });
    };
}]);