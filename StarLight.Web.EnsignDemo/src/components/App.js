import React, { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import pricesData from './prices.json'; // Import the JSON data
import { Autocomplete, TextField } from '@mui/material';
import useSWR from 'swr'

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
  // const { data, error, isLoading } = useSWR('/api/user/123', fetcher)
  const [chartData, setChartData] = useState([]);
  const [selectedSymbols, setSelectedSymbols] = useState([]);
  const colors = ['#8884d8', '#82ca9d', '#ffc658', '#ff7300', '#d7305f', '#e0e0e0', '#f0f0f0', '#f8f8f8', '#f0f0f0', '#e0e0e0', '#d0d0d0', '#c0c0c0', '#b0b0b0', '#a0a0a0', '#909090', '#808080', '#707070', '#606060', '#505050', '#404040', '#303030', '#202020', '#101010'];

  useEffect(() => {
    const formattedData = mergeData(pricesData);
    setChartData(formattedData);
  }, []);

  const uniqueSymbols = Array.from(new Set(pricesData.map(item => item.securityId)));


  return (
    <>
      <Autocomplete
        multiple
        value = {selectedSymbols}
        disablePortal
        options={uniqueSymbols}
        sx={{ width: 300 }}
        onChange = {(e, newValue) => setSelectedSymbols(newValue)}
        renderInput={(params) => <TextField {...params} label="Select Symbol" />}
      />
      {
        selectedSymbols.length > 0 ?
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
            {selectedSymbols.map((symbol, i) => (
              <Line key={symbol} type="monotone" dataKey={symbol} stroke={colors[i]} activeDot={{ r: 8 }} />
            ))}
          </LineChart>
        </ResponsiveContainer> : <h1>Select Symbol</h1>
      }
    </>
  );
};

export default LineChartComponent;