var NG_APP = 'app/**/*.*';
var JS_APP = 'app/**/*.js';
var HTML_APP = 'app/**/*.html';

var gulp = require('gulp');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var sourcemaps = require('gulp-sourcemaps');
var jshint = require('gulp-jshint');
var clean = require('gulp-clean');
//var minifyCss = require('gulp-minify-css');

gulp.task('default', ['build-dev'], function () { });

gulp.task('build-dev', ['copy-html', 'dev-ng'], function () { });

gulp.task('build-prod', ['copy-html', 'dev-css', 'dev-js', 'prod-ng'], function () { });

gulp.task('watch', function () {
    gulp.watch(NG_APP, ['build-dev']);
});

gulp.task('copy-html', function () {
    gulp.src([HTML_APP]).pipe(gulp.dest('wwwroot'));
});

gulp.task('prod-ng', function () {
    gulp.src([JS_APP, '!gulpfile.js', '!node_modules/**/*.*', '!wwwroot/**/*.*', '!js/**/*.*'])
        .pipe(concat('app.js'))
        .pipe(jshint()).on('error', errorHandler)
        .pipe(uglify()).on('error', errorHandler)
        .pipe(gulp.dest('wwwroot'));
});

gulp.task('dev-ng', function () {
    gulp.src([JS_APP, '!gulpfile.js', '!node_modules/**/*.*', '!wwwroot/**/*.*', '!js/**/*.*'])
        .pipe(sourcemaps.init())
        .pipe(concat('app.js'))
        .pipe(jshint())
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest('wwwroot'));
});

gulp.task('dev-css', function () {
    gulp.src([CSS_APP])
        .pipe(sourcemaps.init())
        .pipe(minifyCss())
        .pipe(sourcemaps.write())
        .pipe(gulp.dest('wwwroot'));
    gulp.src([FONTS_APP])
        .pipe(gulp.dest('wwwroot/css/fonts'));
    gulp.src([IMG_APP])
        .pipe(gulp.dest('wwwroot/imgs'));
});

gulp.task('dev-js', function () {
    gulp.src([JS_DEP_APP])
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(sourcemaps.write())
        .pipe(gulp.dest('wwwroot'));
});

// Handle the error
function errorHandler(error) {
    console.log(error.toString());
    this.emit('end');
}