var gulp = require('gulp');
var scripts = require('./index');
var argv = require('yargs').argv;
var dataMig = require('./data-migration');

gulp.task('destroy-all', function () {
    scripts.queryAndDestroyAllClasses();
});

gulp.task('task1', function () {
    scripts.getProvinceNullDistricts();
});

gulp.task('new-client-def', function () {
	if (argv.CLIENT_NAME) {
		scripts.createNewSegguClientWithDefaults(argv.CLIENT_NAME);
	}
});

gulp.task('login', function () {
	if (argv.USERNAME && argv.PASSWORD) {
		console.log('Gonna try to login as ${argv.USERNAME} with password ${argv.PASSWORD}');
		console.log(argv.USERNAME);
		console.log(argv.PASSWORD);

		scripts.logInAs(argv.USERNAME, argv.PASSWORD);
	}
});

gulp.task('create-provinces', function () {
	// dataMig('http://seggu-api-test.herokuapp.com/parse/', 'seggu-api', 'SegguMasterKey')
	// 	.createProvinces('./data/provinces.json');
});