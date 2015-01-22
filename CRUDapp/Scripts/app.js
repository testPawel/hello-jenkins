var myApp = angular.module('TodoApp', ["ngResource", "ngRoute"]);
//angular.module("TodoApp", ["ngResource", "ngRoute"])
myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
    when('/', {
        templateUrl: 'list.html',
        controller: 'ListCtrl'
    }).when('/new', {
        templateUrl: 'details.html',
        controller: 'CreateCtrl'
    }).
    otherwise({
        redirectTo: '/'
    });

}])
.factory("TodoFactory", function($resource) {
    return $resource('/api/Todo/:id', { id: '@id' }, { update: { method: 'PUT' } });
})



