/// <binding BeforeBuild='less' />
"use strict";

var gulp = require("gulp"),
   // less = require("gulp-less"),  // добавляем модуль less
    sass = require("gulp-sass"); // добавляем модуль sass

var paths = {
    webroot: "./wwwroot/"
};
//  регистрируем задачу по преобразованию styles.less в файл css
//gulp.task("less", function () {
//    return gulp.src('less/styles.less')
//        .pipe(less())
//        .pipe(gulp.dest(paths.webroot + '/css'))

    // регистрируем задачу для конвертации файла scss в css
    gulp.task("sass", function () {
        return gulp.src('Sass/styles2.scss')
            .pipe(sass())
            .pipe(gulp.dest(paths.webroot + '/css'));
});