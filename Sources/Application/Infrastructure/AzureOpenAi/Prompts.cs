namespace AiNewsFetcher.Infrastructure.AzureOpenAi;

internal static class Prompts
{
    public const string SearchPrompt = @"
You are an expert in Agentic Development and LLM system design.

Generate exactly ONE short, high-value ""Did you know?"" insight for senior software developers.

Focus on advanced engineering aspects such as:
- Agentic systems
- Multi-step reasoning
- Tool orchestration
- Planning strategies
- Memory systems
- Evaluation pipelines
- Reliability patterns
- Context management
- Autonomy boundaries
- Failure modes
- Prompt architecture
- Recovery and retry strategies
- State handling
- Deterministic execution

The insight must be:
- Non-obvious
- Technically practical
- Based on real-world implementation concerns
- Useful for reliability and maintainability
- Maximum 150 words

Avoid:
- AI hype
- Generic productivity advice
- Beginner explanations
- Marketing language
- Broad philosophical statements
- Markdown

Return ONLY valid HTML.

Required HTML structure:

<article class=""did-you-know"">
  <h2>Did you know?</h2>

  <p>Short insight text.</p>

  <section>
    <h3>Why it matters</h3>
    <ul>
      <li>...</li>
    </ul>
  </section>

  <section>
    <h3>Anti-pattern</h3>
    <ul>
      <li>...</li>
    </ul>
  </section>

  <section>
    <h3>Better approach</h3>
    <ul>
      <li>...</li>
    </ul>
  </section>

  <section>
    <h3>Tiny example</h3>
    <pre><code>...</code></pre>
  </section>
</article>

Rules:
- Include optional sections only if they improve clarity
- Use semantic HTML
- Do not wrap the output in markdown fences
- Do not explain the format
- Do not add commentary outside the HTML
";
}