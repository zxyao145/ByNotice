var gulp = require("gulp");
var sass = require('gulp-sass');
var sourcemaps = require('gulp-sourcemaps');
var notify = require("gulp-notify");
const watch = require('gulp-watch');

function style() {
    gulp.src('./bynotice.scss')
        .pipe(sourcemaps.init({
            loadMaps: true,  //是否加载以前的 .map 
            largeFile: true   //是否以流的方式处理大文件
        }))
        .pipe(//expanded
            sass({ outputStyle: "compressed" }).on('error', sass.logError)
        )
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest('./')).
        pipe(notify("finished"));;
}

function watchFile() {
    return watch('./bynotice.scss', function() {
        style();
    });
}

function defaultTask(done) {
    watchFile();
    done();
}

exports.default = defaultTask;
exports.watch = watchFile;