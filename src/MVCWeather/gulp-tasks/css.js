export default class CssTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  // Compile Our Sass
  sass() {
    let self = this;
    return () => {
    	return self.gulp.src([
          'Frontend/scss/**/[^_]*.scss',
      ])
      .pipe(self.plugins.sassGlob())
      .pipe(self.plugins.sourcemaps.init())
  		.pipe(self.plugins.sass({outputStyle: 'compressed'}).on('error', self.plugins.sass.logError))
      .pipe(self.plugins.rename('main.min.css'))
      .pipe(self.plugins.sourcemaps.write('.'))
      .pipe(self.gulp.dest('wwwroot/styles'));
    }
  }

  libraryCSSDependencies () {
    let self=  this;
    return () => {
	    return self.gulp.src([
        'node_modules/ng-dialog/css/ngDialog.min.css',
  			'node_modules/ng-dialog/css/ngDialog-theme-default.min.css',
        'node_modules/angular-tooltips/dist/angular-tooltips.min.css',
		  ])
		  .pipe(self.plugins.concat('_css-lib.scss'))
		  .pipe(self.gulp.dest('Frontend/scss/lib'));
    };
  }
}
