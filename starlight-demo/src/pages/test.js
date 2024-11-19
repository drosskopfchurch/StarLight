import React, { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import pricesData from './prices.json'; // Import the JSON data

const mergeData = (data) => {
  const merged = {};
  data.forEach(item => {
    const date = new Date(item.date).toLocaleDateString();
    if (!merged[date]) {
      merged[date] = { date };
    }
    merged[date][item.securityId] = item.close;
  });
  return Object.values(merged);
};

const LineChartComponent = () => {
  const [chartData, setChartData] = useState([]);

  useEffect(() => {
    const formattedData = mergeData(pricesData);
    setChartData(formattedData);
  }, []);

  const uniqueTickers = Array.from(new Set(pricesData.map(item => item.securityId)));

  return (
    <ResponsiveContainer width="100%" height={400}>
      <LineChart
        width={500}
        height={300}
        data={chartData}
        margin={{
          top: 5, right: 30, left: 20, bottom: 5,
        }}
      >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="date" />
        <YAxis />
        <Tooltip />
        <Legend />
        {uniqueTickers.map(ticker => (
          <Line key={ticker} type="monotone" dataKey={ticker} stroke="#8884d8" activeDot={{ r: 8 }} />
        ))}
      </LineChart>
    </ResponsiveContainer>
  );
};

export default LineChartComponent;