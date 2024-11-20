export async function load() {
    return {
        env: Object.entries(process.env).map(([key, value]) => ({ name: key, value })),
        cache: process.env['ConnectionStrings__projectcache'],
        cache2: process.env['ConnectionStrings__project-cache']
    }
}