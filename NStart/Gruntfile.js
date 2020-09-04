/// <binding AfterBuild='externals-update' />
/* Ease of access routes */
var nodeRoot = './node_modules/';
var targetPath = './wwwroot/lib/';
var jqueryTargetPath = './wwwroot/lib/jquery/dist';

module.exports = function (grunt) {
    grunt.initConfig({
        clean: [
            targetPath + 'material-components/*', targetPath + 'jquery/*',
            targetPath + 'jquery-validation/*', targetPath + 'jquery-validation-unobtrusive/*'
        ],
        copy: {
            external: {
                files: [
                    // jQuery Library
                    {
                        src: nodeRoot + "jquery/dist/*",
                        dest: jqueryTargetPath,
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Material Components CSS
                    {
                        src: nodeRoot + "material-components-web/dist/*.css",
                        dest: targetPath + "material-components/css/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Material Components JS
                    {
                        src: nodeRoot + "material-components-web/dist/*.js",
                        dest: targetPath + "material-components/js/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    }
                ]
            }
        }
    });

    /**
     * Grunt NPM Tasks
     */
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");
    /**
     *  Grunt Unified Tasks
     */
    grunt.registerTask("externals-update", ["clean", "copy"]);
};