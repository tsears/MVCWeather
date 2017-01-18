export default class AssetTasks {
  constructor(gulp, plugins) {
    this.gulp = gulp;
    this.plugins = plugins;
  }

  icons() {
    const self = this;
    return () => {
        return self.gulp.src('assets/icons/**/*')
            .pipe(self.gulp.dest('wwwroot/icons'))
    };
  }
}