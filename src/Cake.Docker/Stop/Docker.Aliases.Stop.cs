﻿using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="containers"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerStop(this ICakeContext context, string[] containers)
        {
            DockerStop(context, containers, new DockerBuildSettings());
        }
        /// <summary>
        /// Stops a <paramref name="container"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="container"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerStop(this ICakeContext context, string container)
        {
            DockerStop(context, new string[] { container });
        }
        /// <summary>
        /// Stops a <paramref name="container"/> using the given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="container"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerStop(this ICakeContext context, string container, DockerBuildSettings settings)
        {
            DockerStop(context, new string[] { container }, settings);
        }
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="containers"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
		public static void DockerStop(this ICakeContext context, string[] containers, DockerBuildSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            var runner = new GenericDockerRunner<DockerBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("stop", settings ?? new DockerBuildSettings(), containers);
        }
    }
}
