"use client";
import React, { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import { Autocomplete, Stack, TextField, Typography } from '@mui/material';

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

const DemoGraph = ({ graphData }) => {
    const [chartData, setChartData] = useState([]);
    const [selectedSymbols, setSelectedSymbols] = useState([]);
    const [uniqueSymbols, setUniqueSymbols] = useState([]);
    const colors = ['#8884d8', '#82ca9d', '#ffc658', '#ff7300', '#d7305f', '#e0e0e0', '#f0f0f0', '#f8f8f8', '#f0f0f0', '#e0e0e0', '#d0d0d0', '#c0c0c0', '#b0b0b0', '#a0a0a0', '#909090', '#808080', '#707070', '#606060', '#505050', '#404040', '#303030', '#202020', '#101010'];
    useEffect(() => {
        if (graphData) {
            const formattedData = mergeData(graphData);
            setChartData(formattedData);
            setUniqueSymbols(Array.from(new Set(graphData.map(item => item.securityId))));
        }
    }, [graphData]);
    return (
        <Stack spacing={4}>
            <Autocomplete
                multiple
                value={selectedSymbols}
                disablePortal
                options={uniqueSymbols}
                sx={{ width: 300 }}
                onChange={(e, newValue) => setSelectedSymbols(newValue)}
                renderInput={(params) => <TextField {...params} label="Select Symbol" />}
            />
            {
                selectedSymbols && selectedSymbols.length > 0 ?
                    <>
                        <Typography component="h3" gutterBottom>
                            Graph
                        </Typography>
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
                                    <Line key={i} type="monotone" dataKey={symbol} stroke={colors[i]} activeDot={{ r: 8 }} />
                                ))}
                            </LineChart>
                        </ResponsiveContainer>
                    </> : <></>
            }
        </Stack>
    );
}

export default DemoGraph;