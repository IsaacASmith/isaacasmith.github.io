<template>
  <div>
    <PostLayout
      :title="postDefinition.title"
      :publish-date="postDefinition.publishDate"
      :tags="postDefinition.tags"
      :thumbnail="postDefinition.thumbnail"
    >
      <p class="mb-6">
        Two of the largest players in the .NET ORM space are entity framework
        (11k github stars) and dapper (14k github stars). Entity framework is
        the Microsoft backed ORM based around 1-1 mappings between C# models and
        SQL objects. Dapper is built closer to the SQL language, where SQL
        queries are written in your C# code and the parameters/results are
        mapped back and forth to your C# models automatically.
      </p>
      <p class="mb-6">
        With these two great choices available, it can be difficult to decide
        when one is warranted over the other. In this article we’ll lay out
        similarities, differences, and what considerations I make when choosing
        one over the other. If you’re not sure, you can always use both in the
        same project.
      </p>
      <p class="mb-1 font-semibold">Contents</p>
      <ul class="list-decimal underline ml-6 mb-10">
        <li>
          <a href="#similarities">Similarities</a>
        </li>
        <li>
          <a href="#differences">Differences</a>
        </li>
        <li>
          <a href="#scenarios">Which is best for your scenario?</a>
        </li>
      </ul>
      <h2 id="similarities" class="mb-2 text-2xl font-bold">Similarities</h2>
      <p class="mb-6">
        There are a lot of common attributes between the two ORMs, and a lot of
        the concepts you’ll need to understand in one will carry over to the
        other.
      </p>
      <p class="font-semibold">Model Mapping</p>
      <p class="mb-6">
        Each ORM will handle taking the results of SQL queries and mapping them
        into your C# objects automatically.
      </p>
      <p class="font-semibold">Query Parameterization</p>
      <p class="mb-6">
        With SQL injection still among the top vulnerabilities in web
        applications, dapper and EF can handle query parameterization for you.
      </p>
      <p class="font-semibold">Connection Management</p>
      <p class="mb-6">
        Both will manage your SQL connection pool and reuse connections as
        appropriate.
      </p>
      <p class="font-semibold">Executing Custom Queries</p>
      <p class="mb-6">
        Although dapper has better support for this, both ORMs provide
        functionality to run custom SQL queries and read those results back into
        C# models.
      </p>
      <p class="font-semibold">Pricing/Licensing</p>
      <p class="mb-6">Both libraries are free and open source.</p>
      <p class="font-semibold">Community Support</p>
      <p class="mb-16">
        Both libraries have a vast community behind them, which provide
        continuous updates as well as documentation and forums for getting help.
      </p>
      <Affiliate />
      <h2 id="differences" class="mb-2 text-2xl font-bold">Differences</h2>
      <p class="mb-6">
        Although each library has a lot in common, there are a few developer and
        technical differences between the two ORMs to keep in mind.
      </p>
      <p class="font-bold mb-2 text-xl">
        Developer Experience / Maintainability
      </p>
      <p class="font-semibold">Entity Framework</p>
      <p class="mb-6">
        EF comes with a variety of tools for developer productivity. Whether
        you’re taking a code-first approach or a database-first approach, there
        are tools to generate SQL tables or C# models and a db context. This can
        save a lot of headache when trying to keep your models and database in
        sync as changes are made. EF also saves developer time by removing the
        need to write queries.
      </p>
      <p class="font-semibold">Dapper</p>
      <p class="mb-6">
        Compared to EF, dapper is pretty lacking on the tooling and developer
        experience front. You’re on your own if there are changes to the
        database tables you’re querying. If you modify columns, you’ll have to
        find all of your queries that reference that table and update them to
        match the new table definition. This is one of the biggest
        maintainability headaches with dapper.
      </p>
      <p class="font-bold mb-2 text-xl">Change Tracking</p>
      <p class="font-semibold">Entity Framework</p>
      <p class="mb-6">
        EF has built in change tracking. This means that any time you read out a
        model from the database and make changes, you can automatically save
        those changes right back to the database without any additional work.
        This does come with some performance overhead, but not a lot in most
        scenarios.
      </p>
      <p class="font-semibold">Dapper</p>
      <p class="mb-6">
        There is no support for automated change tracking in dapper. Any updates
        to models will have to be manually written out in SQL and executed
        against the database.
      </p>
      <p class="font-bold mb-2 text-xl">Query Control/Performance</p>
      <p class="font-semibold">Entity Framework</p>
      <p class="mb-6">
        With EF, you have very limited control over the queries being generated.
        The only way to control the queries is by restructuring linq statements
        to change the way the SQL is generated. By choosing EF you give up some
        control over the way the queries are structured, but you’ll save a lot
        of time not writing SQL. EF has also been known to be much slower than
        other options for querying and getting results back, although it has
        made a lot of strides in improving performance.
      </p>
      <p class="font-semibold">Dapper</p>
      <p class="mb-4">
        One upside of dapper is that you have full control of the queries
        running against your database. The query performance is fully up to the
        developer. It’s easier to see when queries will have performance issues
        since the queries are defined up front, rather than hidden behind entity
        framework’s black box of query generation. There are certain situations
        that EF will not handle well, and you have little control to change it.
      </p>
      <p class="mb-6">
        Being a micro-ORM, dapper is one of the most performant ways to run SQL
        statements and map the results back into C# models. So if performance is
        your biggest concern, dapper is a no-brainer.
      </p>
      <p class="font-bold mb-2 text-xl">Flexibility</p>
      <p class="font-semibold">Entity Framework</p>
      <p class="mb-4">
        EF expects your data to be fairly well normalized and relies on foreign
        keys to determine object relationships in your C# models. If your
        database is not well normalized, EF will be tough to work with.
      </p>
      <p class="mb-6">
        Dealing with stored procedures and raw SQL queries is also a pain when
        using entity framework. There is support for these scenarios, but it’s
        not as easy or out of the box as using dapper.
      </p>
      <p class="font-semibold">Dapper</p>
      <p class="mb-16">
        Dapper is able to handle pretty much any database structure or scenario
        you throw at it. Denormalized tables? No problem. Missing foreign keys?
        No issues there. Running stored procedures? Great.
      </p>
      <h2 id="scenarios" class="mb-2 text-2xl font-bold">
        Which is best for your scenario?
      </h2>
      <p class="mb-8">
        Each situation will be different when deciding between these ORMs, so
        here are some questions I ask myself to help make a choice between EF
        and dapper.
      </p>
      <p class="text-xl font-semibold">Does my database have foreign keys?</p>
      <p class="mb-4">If not, dapper is probably the way to go.</p>
      <p class="mb-8">
        This is always my first question, and can make the decision clear right
        away. Entity framework will not play nicely with navigation properties
        if your database is missing foreign keys. While it would be best to get
        foreign keys added, it’s not always an option.
      </p>
      <p class="text-xl font-semibold">
        Is database performance a major concern?
      </p>
      <p class="mb-4">If yes, dapper is a good fit.</p>
      <p class="mb-8">
        While EF is catching up to dapper in performance, dapper still holds the
        lead. Check out
        <a
          href="https://www.exceptionnotfound.net/dapper-vs-entity-framework-core-query-performance-benchmarking-2019"
          rel="nofollow"
          target="_blank"
          class="underline"
          >this article</a
        >
        for a performance comparison.
      </p>
      <p class="text-xl font-semibold">
        Am I doing lots of create and update operations?
      </p>
      <p class="mb-4">If yes, entity framework may be preferred.</p>
      <p class="mb-6">
        You’ll save a lot of headache by choosing entity framework in this
        scenario, since it will automatically track changes and generate the
        queries to save those changes without your intervention.
      </p>
      <p class="flex flex-row justify-center mt-4 mb-8 text-xl font-bold">
        . . .
      </p>
      <h2 class="mb-2 text-2xl">
        <strong>Wrap Up</strong>
      </h2>
      <p class="mb-6">
        There are lots of great features in both entity framework and dapper.
        The choice between the two will always be context dependent, but having
        knowledge about each ORM will give you confidence in the decision to use
        one or the other (or use both).
      </p>
    </PostLayout>
  </div>
</template>

<script>
import PostLayout from '@/components/post-layout.vue'
import Affiliate from '@/components/affiliate.vue'
import blogDefinition from '~/plugins/blog-definition.js'

export default {
  components: { PostLayout, Affiliate },
  data: () => ({
    blogDefinition,
  }),
  head() {
    return {
      title: 'Entity Framework vs Dapper - Which .NET ORM Should I Use?',
      meta: [
        {
          hid: 'ef-vs-dapper-description',
          name: 'description',
          content:
            "Dapper and EF are two of the most popular ORMs in the .NET ecosystem. There are various reasons to choose one over the other. Let's explore a few.",
        },
      ],
    }
  },
  computed: {
    postDefinition() {
      return this.blogDefinition.posts.find(
        (post) => post.url === '/blog/2022/entity-framework-vs-dapper'
      )
    },
  },
}
</script>
