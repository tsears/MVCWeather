export default class DevTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  watch() {
    let self = this;
    return () => {
      self.gulp.watch('widgets/**/*.js', ['lint', 'scriptCompile']);
      self.gulp.watch('widgets/**/*.scss', ['sass']);
      self.gulp.watch('widgets/**/*.html', ['angularPartials']);
    }
  }

  monitor() {
    let self = this;
    return () => {
      self.plugins.nodemon({
    		script: 'index.js',
    		ext: 'js html',
    		tasks: ['lint'],
    		watch: ['index.js'],
    		env: {
    			'NODE_ENV': 'development'
    		},
    		"ignore": [
    			".git",
    			"node_modules/**/node_modules",
    			"*.min.js",
    			"widgets/**/*.js"
    		],
    		legacyWatch: true
    	}).on('restart', () => {
    		console.log('Restarting....');
    	});
    }
  }
}
