import { useState } from "react";
import { getPokemonByName } from "./api";

const emptyPokemon = {
  id: null,
  name: "",
  baseExperience: null,
  height: null,
  isDefault: null,
  order: null,
  weight: null
};

export default function App() {
  const [name, setName] = useState("");
  const [pokemon, setPokemon] = useState(null);
  const [status, setStatus] = useState({
    type: "idle",
    message: "Digite um nome e consulte a API."
  });
  const [isLoading, setIsLoading] = useState(false);

  async function handleSubmit(event) {
    event.preventDefault();

    const trimmedName = name.trim();
    if (!trimmedName) {
      setStatus({
        type: "error",
        message: "Informe o nome de um pokemon para realizar a busca."
      });
      setPokemon(null);
      return;
    }

    setIsLoading(true);
    setStatus({
      type: "loading",
      message: `Buscando ${trimmedName}...`
    });

    try {
      const data = await getPokemonByName(trimmedName);
      setPokemon({
        id: data.id ?? emptyPokemon.id,
        name: data.name ?? emptyPokemon.name,
        baseExperience: data.baseExperience ?? emptyPokemon.baseExperience,
        height: data.height ?? emptyPokemon.height,
        isDefault: data.isDefault ?? emptyPokemon.isDefault,
        order: data.order ?? emptyPokemon.order,
        weight: data.weight ?? emptyPokemon.weight
      });
      setStatus({
        type: "success",
        message: "Pokemon encontrado com sucesso."
      });
    } catch (error) {
      setPokemon(null);
      setStatus({
        type: "error",
        message: error.message
      });
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <main className="page-shell">
      <section className="hero-card">
        <div className="hero-copy">
          <span className="eyebrow">PokemonAPI + React</span>
          <h1>Base pronta para evoluir o front-end.</h1>
          <p>
            Esta interface React consome o endpoint existente do backend ASP.NET
            e deixa o fluxo preparado para desenvolvimento incremental.
          </p>
        </div>

        <form className="search-panel" onSubmit={handleSubmit}>
          <label className="field-label" htmlFor="pokemon-name">
            Nome do pokemon
          </label>
          <div className="field-row">
            <input
              id="pokemon-name"
              name="pokemon-name"
              type="text"
              value={name}
              onChange={(event) => setName(event.target.value)}
              placeholder="Ex.: pikachu"
              autoComplete="off"
            />
            <button type="submit" disabled={isLoading}>
              {isLoading ? "Buscando..." : "Buscar"}
            </button>
          </div>

          <p className={`status status-${status.type}`}>{status.message}</p>
        </form>
      </section>

      <section className="results-grid">
        <article className="metric-card accent-yellow">
          <span className="metric-label">ID</span>
          <strong>{pokemon?.id ?? "--"}</strong>
        </article>
        <article className="metric-card accent-red">
          <span className="metric-label">Nome</span>
          <strong>{pokemon?.name || "--"}</strong>
        </article>
        <article className="metric-card accent-blue">
          <span className="metric-label">Base Experience</span>
          <strong>{pokemon?.baseExperience ?? "--"}</strong>
        </article>
        <article className="metric-card accent-green">
          <span className="metric-label">Height</span>
          <strong>{pokemon?.height ?? "--"}</strong>
        </article>
        <article className="metric-card accent-orange">
          <span className="metric-label">Is Default</span>
          <strong>
            {pokemon?.isDefault === null || pokemon?.isDefault === undefined
              ? "--"
              : pokemon.isDefault
                ? "true"
                : "false"}
          </strong>
        </article>
        <article className="metric-card accent-navy">
          <span className="metric-label">Order</span>
          <strong>{pokemon?.order ?? "--"}</strong>
        </article>
        <article className="metric-card accent-pink">
          <span className="metric-label">Weight</span>
          <strong>{pokemon?.weight ?? "--"}</strong>
        </article>
      </section>
    </main>
  );
}
