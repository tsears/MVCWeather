"use strict";
import gulp from 'gulp';
import sass from 'gulp-sass';
import sassGlob from 'gulp-sass-glob';
import sourceMaps from 'gulp-sourcemaps';
import rename from 'gulp-rename';

gulp.task('sass', () => {
    gulp.src('Frontend/scss/**/[^_]*.scss')
      .pipe(sourceMaps.init())
      .pipe(sass({outputStyle: 'compressed'}).on('error', sass.logError))
      .pipe(rename('main.min.css'))
      .pipe(sourceMaps.write('.'))
      .pipe(gulp.dest('wwwroot/styles'));
});

gulp.task('default', ['sass'], () => {
    gulp.watch('Frontend/**/*.scss', ['sass']);
})
