# Github Actions CI/CD Example WebAPI .NET-8

Embracing the tools that we will describe here, allows you to focus more on coding and less on deployment intricacies, unlocking the potential to transform your software deployment process with the integration of GitHub Actions, Docker Compose, and Watchtower implementing a powerful, automated, and efficient CI/CD pipeline for your projects.

We will be dockerizing a simple backend Web API service and setting up the pipeline for it. It’s worth mentioning that although this solution may not be ideal for larger applications, it’s still a highly effective method for rapidly setting up CI/CD pipelines for less complex applications or testing environments.

Check out the regarding video demostration and article:

    • https://www.youtube.com/watch?v=PzxLvcxJbzw
    • https://github.com/kraftcoding/IT-Document-Collection/blob/master/Kraftcoding%20Articles/Automate%20your%20builds%20with%20GitHub%20Actions%20-%20Kraftcoding%20Article.pdf

## Setting up Docker Hub

We will need a Docker Hub account and container registry or repository to setup our pipelines and store our images. For that, in the Docker Hub dashboard, click on create repository button which you can find on the top right side below the navigation bar. For ore information check out the link below.

    • kraftcoding/githubactionscicdexamplewebapinet general 
    
We will also need access token to be able to push our docker images from github actions. To generate an access token head over to Settings > Personal Access Token > Generate New Token.
Setting up Github Actions

Now, let’s add a Github Actions workflow to the repository. We will need a GitHub account for that.

In the local project with the Visual Studio or any other IDE, create a directory named .github in the root of the solution folder and inside that directory create another directory named workflows. All our workflow files will be stored inside this directory.

Now, create a file named deploy-to-docker-hub.yml which will make the complete path as .github/workflows/deploy-to-docker-hub.yml.

As we can see in the source code provided, we have also a Dockerfile reference in our project directory with which we can build our docker image.

In addition we will need too, the Docker Composite file called docker-compose.yml to define the container’s features that will be created from the image.

Once we have all the need files, use your Docker Hub username and password created earlier to setup the secret variables in your GitHub repository Settings > Security > Secrets and variables > Actions configuration section.

Now, whenever we push to master branch, a new build will be triggered which will build and push the image to docker hub. The workflow is pretty simple and fast to execute and you may also extend it with running tests or performing other actions as per your requirements.

## Initial deploy

In order to have a running container based in the image together with the Watchtower agent that will check for updates in the Docker Hub repository (that we pushed earlier to Docker Hub), execute the following command:

```bash
docker compose up -d
```

As we can see, we are also pulling the watchtower image and running it in our machine.

This watchtower container will scan the repository of specified container names every 30 seconds pull and replace the running container with a new image if it finds one.
Run the command below to view the logs of watchtower container:

```bash
docker logs watchtower
```

We can see from the logs that watchtower has started scanning our repository for new images.

In cases of private repositories, watchtower will need additional configuration to scan repo for new images.
