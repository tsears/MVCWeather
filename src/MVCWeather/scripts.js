export default class ScriptTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  lint() {
    let self = this;
  	return () => {
      return self.gulp.src([
  			'gulpfile.js',
  			'widgets/**/*.js',
  			'!**/*.min.js',
  			'!**/static/**/*.js'
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
        'node_modules/angular-animate/angular-animate.min.js'
  		])
  		.pipe(self.plugins.concat('nglib.js'))
  		.pipe(self.plugins.uglify({
        preserveComments: 'license'
      }))
  		.pipe(self.gulp.dest('static/js/lib'));
    }
  }

  angularPartials() {
    let self = this;
    return () => {
      return self.gulp.src(['widgets/**/*.html'])
		  .pipe(self.gulp.dest('static/ng-partials'));
    }
  }

  scriptCompile() {
    let self = this;
    return () => {
    	return self.gulp.src('widgets/widgets.js')
    		.pipe(self.plugins.webpackStream({
    				module: {
    					loaders: [{
    						loader: 'babel-loader'
    					}]
    				},
    				output: {
    					filename: 'lsg-controls.min.js'
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
    		.pipe(self.gulp.dest('static/js'))
    		.pipe(self.gulp.dest('dist'))
    		.pipe(self.plugins.sourcemaps.write('.'));
    }
  }
}
