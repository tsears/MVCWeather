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
}
