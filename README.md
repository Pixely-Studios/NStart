# NStart
#### A drop-in solution for landing pages of Videogame companies

![.NET Core Build Only](https://github.com/OnlyOnePro/NStart/workflows/.NET%20Core%20Build%20Only/badge.svg)
![.NET Core Test Only](https://github.com/OnlyOnePro/NStart/workflows/.NET%20Core%20Test%20Only/badge.svg)
![CodeQL](https://github.com/Pixely-Studios/NStart/workflows/CodeQL/badge.svg)

---

## Quick word

Wow, didn't notice all the attention with the repo... I'm now ashamed of myself for putting something out there and not updating it :V, better late than never I guess 😅.

I performed a heavy maintenance to the project to update it to .NET 8 and put it up to speed. I forgot to add some stuff in the startup guide (like run grunt to set up your lib folder for local development), and 
thanks to [Heroku clossing their free tiers](https://help.heroku.com/RSBRUH58/removal-of-heroku-free-product-plans-faq) this project is not longer hosted on a public website. I plan to change this up by hosting on
Azure and will let you guys know when this is up by removing this part and updating the Readme file. Also will try to set up a Wiki explaining a little bit more what this project does and how can it suit you.

---

## What is this project?

NStart (pronounced "And Start!") is a small solution for landing pages (or press-kits) for the videogame industry.

Well, I was talking to one of my closest friend & college about how we would promote our videogame and our studio using the most effective methods to gather visibility from online media.
After a couple of lectures and articles about SEO, I was confident enough that I started to implement SEO techniques in Pixely's own site (Currently not available to the public), and I decided 
to make a small and Open Source project that **anyone** can use without any complications.

I didn't knew that `dopresskit()` was a "thing"... And I wasn't able to install it on my development server, so I deemed that project dead and decided to continue open sourcing this.

*A public instance is running on [Heroku](https://nstart.herokuapp.com) using the same Dockerfile for hosting via Herkou Containers.*

## What technologies uses this project?

- ASP.NET Core 5: Using the world's second largest technology stack, we can deliver a fast and reliable platform that will not fail you.
- BulmaCSS: A very powerful & compact CSS framework. No JS, no bloatware and no compromises: just start creating beautiful sites.
- Grunt: Automation with specific rulesets for this particular workflow... I didn't felt like having to do that every time I updated the project's dependences 😉
- Razor: ASP.NET's Template engine. Powerful and highly capable of powering any dream you might think off.

## How will this project ensure me *visibility*

This project uses a series of rulesets very familiar enough to SEO Engineers that you can use to leverage the power of the search engines of the ✨INTERNET✨.

**DISCLAIMER:** I'm **NOT** a SEO Engineer. I used techniques that I read about with documentation available to everybody. Yes, more techniques do exist and there might be better ways to implement 
the ones that this platform uses... so feel free to make a *fork* request, change the code and do a *pull* submission. We all win.

- Scheme.org metadata: Using scheme.org metadata you can generate those nifty and cool smart cards like when you search for Google or Apple. This metadata ensures that if anyone search for your company 
(provided that you are using correctly this metadata), will see those awesome smart cards.
- Globalization & Localization: This platform leverages internal ASP.NET capabilities to localize the entire application. Now you can show a Spanish visitor the same site as everybody else, but translated to their language.
This is a manual process and depends on you to Globalize for your target audiences, but this ensures you global visibility helping you to boost a little bit your sales.
- High loading speeds & low dependencies amount: You won't believe the amount of visitors that bounce off your site just because it loads 1s slower that they want to. We ensure low amount of dependencies + a robust platform, so 
low speeds are no more a problem for your studio (This WILL NOT replace scalability. If your instance experiences a shit-ton of traffic you might want to scale up, but that is out of our scope).
- Social Media Tags: The platform is ready for exposure on social media, whether its on Facebook or Twitter. Leverage the power of OpenGraph & Twitter Cards to make your social media posts pop!

Those are what I think the biggest points of this platform and how it will help you. Of course, none of this will work if you do Black-Hat SEO stuff, like back-link farms. That depends on you to investigate what is that.

## I'm sold. What do I do now?

For starters, download this repository and ensure that you have installed in your PC via [this link](https://dotnet.microsoft.com/download/dotnet-core). For now you need the SDK too, in order to compile the platform and run it, 
I don't have a reliable Internet connection to hook this repository to Docker Composer or make releases on GitHub, so this is something I cannot do.

With the downloaded repository, enter the folder and run:

```
    dotnet restore
    dotnet run
```

For the restore operation you need a Internet connection. After the execution, the platform should be by default available under `https://localhost:5001` and a Kestrel console should pop up reporting the status of the application.

For deploying and hosting it, I will try to make a Wiki explaining everything, but as you can see I'm limited on those subjects.

## What's on the future right now?

Well, first thing we should make a more visually compelling site. I just made scaffolded and basic templates in Razor just for the sake of saving time and simplicity, 
but I don't like them too much and they should be probably fixed and upgraded.
Secondly, I need somebody to help me do a automated action to deploy this to Docker Composer && as a released package right here on GitHub.
And lastly, I will need help with somebody on the wiki for the Deployment side of the tutorial

After those important things are fixed, we can focus on adding potential features, features that do not break the simplicity of the platform of course.
