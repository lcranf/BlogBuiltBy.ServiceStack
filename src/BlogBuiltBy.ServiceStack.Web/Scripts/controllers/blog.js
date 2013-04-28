function BlogCtrl($scope, $http) {

    $http.get('/blogs').success(function(data) {
        $scope.blogs = data;
    });

    $scope.editBlog = function(blog) {

    };



    $scope.deleteBlog = function(idx) {
        var blogToDelete = $scope.blogs[idx];
        
        //TODO: delete blog via web api
        $http.post('blog/delete/' + blogToDelete.Id).success(function(data) {
            console.log(data);
        });
        $scope.blogs.splice(idx, 1);
    };
}