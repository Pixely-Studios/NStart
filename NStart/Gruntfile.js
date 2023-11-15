/// <binding AfterBuild='externals-update' />
/* eslint-disable no-undef */

/* Ease of access routes */
var nodeRoot = './node_modules/';
var targetPath = './wwwroot/lib/';
var jqueryTargetPath = './wwwroot/lib/jquery/dist';

module.exports = function (grunt) {
    grunt.initConfig({
        clean: [
            targetPath + 'animatecss/*',
            targetPath + 'material-components/*', targetPath + 'jquery/*',
            targetPath + 'jquery-validation/*', targetPath + 'jquery-validation-unobtrusive/*'
        ],
        copy: {
            external: {
                files: [
                    // AnimateCSS Library
                    {
                        src: nodeRoot + "animate.css/*.css",
                        dest: targetPath + "animatecss/dist/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Bulma.io CSS
                    {
                        src: nodeRoot + "bulma/css/*",
                        dest: targetPath + "bulma/dist/css",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Bulma Badges
                    {
                        src: nodeRoot + "bulma-badge/dist/css/*",
                        dest: targetPath + "bulma/plugins/bulma-badge/dist/css/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Bulma Tags
                    {
                        src: nodeRoot + "bulma-tagsinput/dist/css/*",
                        dest: targetPath + "bulma/plugins/bulma-tagsinput/dist/css/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    {
                        src: nodeRoot + "bulma-tagsinput/dist/js/*",
                        dest: targetPath + "bulma/plugins/bulma-tagsinput/dist/js/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
                    // Bulma Timeline
                    {
                        src: nodeRoot + "bulma-timeline/dist/css/*",
                        dest: targetPath + "bulma/plugins/bulma-timeline/dist/css/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    },
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