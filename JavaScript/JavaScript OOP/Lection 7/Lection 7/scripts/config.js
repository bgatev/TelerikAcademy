(function () {
   require.config({
       paths: {
           'jquery': '../libraries/jquery-1.11.1',
           'handlebars': '../libraries/handlebars-v1.3.0',
           'combo-box': 'comboBox',
           'data': 'data'
       }
   });

   require(['app'], function (app) {
       app.start();
   });
}());