export default class ScriptTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  lint() {
    const self = this;
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
    const self = this;
    return () => {
    	return self.gulp.src([
  			'node_modules/angular/angular.min.js',
				'node_modules/angular-animate/angular-animate.min.js',
				'node_modules/angular-cookies/angular-cookies.min.js',
				'node_modules/ng-dialog/js/ngDialog.min.js',
				'node_modules/angular-tooltips/dist/angular-tooltips.min.js',
        'node_modules/chart.js/dist/Chart.min.js',
        'node_modules/chartjs-plugin-annotation/chartjs-plugin-annotation.min.js',
        'node_modules/angular-chart.js/dist/angular-chart.js'
  		])
  		.pipe(self.plugins.concat('nglib.js'))
  		.pipe(self.plugins.uglify({
        preserveComments: 'license'
      }))
  		.pipe(self.gulp.dest('wwwroot/js/lib'));
    }
  }

  angularPartials() {
    const self = this;
    return () => {
      return self.gulp.src(['Frontend/**/*.html'])
		  .pipe(self.gulp.dest('wwwroot/ng-partials'));
    }
  }

  scriptCompile() {
    const self = this;
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

	jsTest() {
		const self = this;

		return (done) => {
			new self.plugins.karma.Server (
				{
					configFile: __dirname + '/../karma.conf.js',
					singleRun: true
				}, (err) => {
					if (!err) {
						done();
					} else {
						done(new self.plugins.util.PluginError('karma', {
							message: `Tests failed (${err})`
						}));
					}
				}).start();
		};
	}
}
