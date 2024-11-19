import fetch from 'node-fetch';
import '../../envConfig.js'

export default async function handler(req, res) {
  const { method, url } = req;
  const marketapi = process.env.services__apimarket__https__0 ||
  process.env.services__apimarket__http__0

  switch (method) {
    case 'GET':
      try {
        const response = await fetch(`${marketapi}/${url.replace('/api/', '')}`);
        console.log(marketapi)
        const data = await response.json();
        res.status(200).json(data);
      } catch (error) {
        res.status(500).json({ ...error, url } );
      }
      break;

    case 'POST':
      try {
        const response = await fetch(`${marketapi}/prices`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(req.body),
        });
        const data = await response.json();
        res.status(201).json(data);
      } catch (error) {
        res.status(500).json({ error: 'Failed to create product' });
      }
      break;

    default:
      res.status(405).json({ error: 'Method not allowed' });
  }
}