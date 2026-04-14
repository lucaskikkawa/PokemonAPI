export async function getPokemonByName(name) {
  const response = await fetch(`/api/pokemon/getbyname?nome=${encodeURIComponent(name)}`);

  if (!response.ok) {
    const message = await response.text();
    throw new Error(message || "Ocorreu um erro ao buscar o pokemon.");
  }

  return response.json();
}
