var app = angular.module('feedme', []);



app.controller('SearchController', ["$scope", "$http", function ($scope, $http) {
    var appId = "a758719a";
    var appKey = "4b693aa2976451ab39cbe967b973e454";

    if ($scope.searchterm === undefined) {
        alert("You must enter at least one search term");
    }
    else if ($scope.dietSelect === undefined) {
        $scope.dietSelect = null;
    }
    else if ($scope.healthSelect === undefined) {
        $scope.healthSelect = null;
    }
    else {
        fetch();
    };

    function fetch() {
        $http.get("http//api.edamam.com/search",
            {
                params: {
                    q: $scope.searchterm,
                    diet: $scope.dietSelect,
                    health: $scope.healthSelect,
                    app_id: appId,
                    app_key: appKey
                }
            })
        .success(function (response) {
            $scope.foundrecipes = response;
        })
    }
}])

app.controller('RecipeController', ["$scope", "$http", function ($scope, $http) {




    $scope.test = "test variable";

    $scope.deleteRecipes = function () {
        $http.delete("/api/Test")
            .success(function (data) {
                alert("Recipe Deleted");
            })
            .error(function (error) { alert(error.error) });
    }

    $scope.hello = function () {
        $http.get("/api/Test")
            .success(function (data) {
                $scope.test = data;
            })
            .error(function (error) { alert(error.error) });
    }
}]);