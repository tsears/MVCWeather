export default class ScriptTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  lint() {
    let self = this;
  	return () => {
      return self.gulp.src([
  			'gulpfile.babel.js',
  			'Frontend/**/*.js',
  			'!**/*.min.js',
  			'!**/wwwroot/**/*.js'
  		])
  		.pipe(self.plugins.jshint({
  			'esversion': 6
  		}))
  		.pipe(self.plugins.jshint.reporter('default'));
    }
  }

  angularLib() {
    let self = this;
    return () => {
    	return self.gulp.src([
  			'node_modules/angular/angular.min.js',
  		])
  		.pipe(self.plugins.concat('nglib.js'))
  		.pipe(self.plugins.uglify({
        preserveComments: 'license'
      }))
  		.pipe(self.gulp.dest('wwwroot/js/lib'));
    }
  }

  angularPartials() {
    let self = this;
    return () => {
      return self.gulp.src(['Frontend/**/*.html'])
		  .pipe(self.gulp.dest('wwwroot/ng-partials'));
    }
  }

  scriptCompile() {
    let self = this;
    return () => {
    	return self.gulp.src('Frontend/jsapp/weather.js')
    		.pipe(self.plugins.webpackStream({
    				module: {
    					loaders: [{
    						loader: 'babel-loader'
    					}]
    				},
    				output: {
    					filename: 'weather.min.js'
    				},
    				devtool: 'source-map',
    				plugins: [
    					new self.plugins.webpack.optimize.UglifyJsPlugin({
    						compress: {
    							drop_debugger: false // the linter will warn about the debugger statement, assume it's there intentionally
    						}
    					})
    				]
    		}))
    		.pipe(self.plugins.sourcemaps.init())
    		.pipe(self.gulp.dest('wwwroot/js'))
    		.pipe(self.plugins.sourcemaps.write('.'));
    }
  }
}
