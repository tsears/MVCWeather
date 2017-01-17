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
          'scss/**/[^_]*.scss',
      ])
      .pipe(self.plugins.sassGlob())
      .pipe(self.plugins.sourcemaps.init())
  		.pipe(self.plugins.sass({outputStyle: 'compressed'}).on('error', self.plugins.sass.logError))
      .pipe(self.plugins.sourcemaps.write('.'))
  		.pipe(self.gulp.dest('static/styles'))
      .pipe(self.plugins.rename('lsg-controls.css'))
      .pipe(self.plugins.sourcemaps.write('.'))
      .pipe(self.gulp.dest('dist'));
    }
  }

  borrowedCss() {
    let self = this;
    return () => {
      return self.gulp.src([
        'borrowedStyles/**/*.css'
      ])
      .pipe(self.plugins.concat('default.css'))
      .pipe(self.gulp.dest('static/styles'));
    };
  }

  compileStyleGuide() {
    let self = this;
    return () => {
      return self.gulp.src([
        'styleguide/styleguide.scss'
      ])
      .pipe(self.plugins.sourcemaps.init())
      .pipe(self.plugins.sass().on('error', self.plugins.sass.logError))
      .pipe(self.plugins.sourcemaps.write('.'))
      .pipe(self.gulp.dest('static/styles'));
    }
  }

  fontFaces() {
    let self = this;
    return () => {
  		return self.gulp.src([
  			'styleGuide/font/*'
  		])
  		.pipe(self.gulp.dest('static/styles/font'));
    };
  };

  icons() {
    let self = this;
    return () => {
    	return self.gulp.src([
    		'styleGuide/icon/*'
    	])
    	.pipe(self.gulp.dest('static/styles/icon'));
    };
  }
}
