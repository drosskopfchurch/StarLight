export const dynamic = 'force-static'

export async function GET(req) {
    debugger
    const { url } = req;
    const marketapi = process.env.services__apimarket__https__0 ||
        process.env.services__apimarket__http__0
    // console.log(JSON.stringify(req))
    const fetchUrl = `${marketapi}/${url.replace('http://localhost:3000/api/', '')}`
    console.log(fetchUrl)
    const res = await fetch(`${fetchUrl}`)
    const data = await res.json()

    return Response.json({ data })
}