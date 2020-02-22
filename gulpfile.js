var gulp = require('gulp');

var exec = require('child_process').exec;

gulp.task('default', function (cb) {
    exec('ng build --prod', function (err) {
        cb(err);
    });
});
