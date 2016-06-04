var gulp = require('gulp');
var scripts = require('./index');

gulp.task('destroy-all', function () {
    scripts.queryAndDestroyAllClasses();
});

gulp.task('task1', function () {
    scripts.getProvinceNullDistricts();
})