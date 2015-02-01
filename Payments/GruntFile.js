module.exports = function (grunt) {
    grunt.initConfig({
        //this loads our packages for our grunt file
        pkg: grunt.file.readJSON('package.json'),

        //this section does our bower installs for us
        bower: {
            install: {
                options: {
                    targetDir: './scripts/vendor',
                    layout: 'byComponent',
                    install: true,
                    verbose: true,
                    cleanTargetDir: false,
                    cleanBowerDir: false,
                    bowerOptions: {}
                }
            }
        }
    });

    //npm modules need for our task
    grunt.loadNpmTasks('grunt-bower-task');

    //run bower for package install
    grunt.registerTask('install-bower-packages', ['bower']);
};