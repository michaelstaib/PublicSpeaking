const plugin = {
  name: 'plugin-cache-dir',
  factory: (require) => ({
    hooks: {
      async setupScriptEnvironment({configuration}, scriptEnv) {
        if (scriptEnv.CACHE_DIR === undefined) {
          const {npath} = require('@yarnpkg/fslib');

          scriptEnv.CACHE_DIR = npath.join(
            npath.fromPortablePath(
              configuration.projectCwd ?? configuration.startingCwd,
            ),
            '.tmp',
            'cache',
          );
        }
      },
    },
  }),
};

module.exports = plugin;
