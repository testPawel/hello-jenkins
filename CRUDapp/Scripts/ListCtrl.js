angular.module('TodoApp').controller('ListCtrl', ['$scope', 'TodoFactory', function ($scope, TodoFactory) {
    $scope.todoes = TodoFactory.query();

    $scope.search = function () {
        TodoFactory.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit },
            function (data) {
                $scope.more = data.length === 20;
                $scope.todoes = $scope.todoes.concat(data);
            });
    };

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        };
        $scope.reset();
    };

    $scope.show_more = function () {
        $scope.offset += $scope.limit;
        $scope.search();
    };
    $scope.has_more = function () {
        return $scope.more;
    };

    $scope.reset = function () {
        $scope.limit = 20;
        $scope.offset = 0;
        $scope.todoes = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.delete = function () {
        var id = this.todo.ItemId;
        TodoFactory.delete({ id: id }, function () {
            $('#restaurant_' + id).fadeOut();
        });
    };

    $scope.sort_order = "Adress";
    $scope.is_desc = false;
  

    $scope.reset();
}]);